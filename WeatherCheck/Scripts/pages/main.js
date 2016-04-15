app.controller("HomeController", ["$scope", "$http", "$timeout", function($scope, $http, $timeout) {
    $scope.loadCities = function() {
        $http.get("/api/cities?country=" + $scope.Country).then(function (response) {
            $scope.Cities = response.data;
        }, function (response) {
            $scope.Cities = [];
        });
    };

    $scope.loadCityTimeout = null;
    $scope.tryLoadCities = function () {
        if ($scope.loadCityTimeout) {
            $timeout.cancel($scope.loadCityTimeout);
            $scope.loadCityTimeout = null;
        }

        // shortest country name is 4 letters
        if ($scope.Country != null && $scope.Country.length > 3) {
            $scope.loadCityTimeout = $timeout(function() {
                $scope.loadCities();
            }, 3000);
        }
    };
}]);