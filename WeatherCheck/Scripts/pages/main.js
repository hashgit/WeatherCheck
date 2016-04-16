app.controller("HomeController", ["$scope", "$http", "$timeout", "AppUtils", function ($scope, $http, $timeout, utils) {

    $scope.CityMessage = "enter name of a country to get list of cities";

    $scope.loadCities = function () {
        // shortest country name is 3 letters
        if ($scope.Country != null && $scope.Country.length >= utils.Constants.CountryNameMinSize) {
            $scope.loadingCity = true;
            $http.get("/api/cities?country=" + $scope.Country).then(function(response) {
                $scope.Cities = response.data;
                $scope.City = $scope.Cities[0];
                $scope.loadingCity = false;
                $scope.ErrorMessage = null;
                if (response.data.length === 0) {
                    $scope.CityMessage = "country not found";
                }
            }, function(response) {
                $scope.Cities = [];
                $scope.loadingCity = false;
                $scope.ErrorMessage = response.data.ExceptionMessage;
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
        }, 2000);
    };

    $scope.loadWeather = function() {
        if ($scope.City != null) {
            $http.get("/api/weather?country=" + $scope.City.Country + "&city=" + $scope.City.City).then(function (response) {
                $scope.Weather = response.data;
                $scope.ErrorMessage = null;
            }, function (response) {
                $scope.Weather = null;
                $scope.ErrorMessage = response.data.ExceptionMessage;
            });
        }
    };
}]);