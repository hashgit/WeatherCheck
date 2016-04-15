app.controller("HomeController", ["$scope", "$http", "$timeout", function ($scope, $http, $timeout) {

    $scope.loadCities = function () {
        // shortest country name is 3 letters
        if ($scope.Country != null && $scope.Country.length > 2) {
            $http.get("/api/cities?country=" + $scope.Country).then(function(response) {
                $scope.Cities = response.data;
                $scope.City = $scope.Cities[0];
            }, function(response) {
                $scope.Cities = [];
            });
        } else {
            $scope.Cities = [];
        }

        $scope.Weather = null;
    };

    $scope.loadCityTimeout = null;
    $scope.tryLoadCities = function () {
        if ($scope.loadCityTimeout) {
            $timeout.cancel($scope.loadCityTimeout);
            $scope.loadCityTimeout = null;
        }

        $scope.loadCityTimeout = $timeout(function() {
            $scope.loadCities();
        }, 3000);
    };

    $scope.loadWeather = function() {
        if ($scope.City != null) {
            $http.get("/api/weather?country=" + $scope.City.Country + "&city=" + $scope.City.City).then(function (response) {
                $scope.Weather = response.data;
            }, function (response) {
                $scope.Weather = null;
            });
        }
    };
}]);