var app = angular.module("infoTrackApp", []);

app.controller("InfoTrackController", function ($scope, $http) {
    $scope.keywordToSearch = "";
    $scope.url = "";
    $scope.ranks = null;
    $scope.error = null;
    $scope.show = false;
    $scope.searchResultsList = [];

    $scope.selectedSearchEngine = null;

    $scope.searchEngines = [
        { name: "Google" },
        { name: "Bing" }
    ];


    $scope.getInfoTrackRanks = function () {
        $http.post("/Home/GetInfoTrackRanks", { keywordToSearch: $scope.keywordToSearch, url: $scope.url, searchEngine: $scope.selectedSearchEngine})
            .then(function (response) {
                if (response.data.Ranks) {
                    $scope.ranks = response.data.Ranks;
                    $scope.error = null;
                    $scope.show = false;
                    $scope.searchResultsList = [];
                } else {
                    $scope.ranks = null;
                    $scope.error = response.data.Error;
                }
            }, function (error) {
                $scope.error = "An error occurred.";
                console.log(error);
            });
    };

    $scope.getSearchResultsHistory = function () {
        $http.get("/Home/GetSearchResultsHistory")
            .then(function (response) {
                $scope.searchResultsList = response.data;
                $scope.show = true;
            }, function (error) {
                console.log(error);
            });
    };
});

