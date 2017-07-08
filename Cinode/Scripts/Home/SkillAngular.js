var skillApp = angular.module("skillApp", []);
skillApp.controller("skillCtrl", ['$scope', '$http', function ($scope, $http) {

    $scope.name = null;
    $scope.rate = null;
    $scope.id = null;
    var id = 0;
    $scope.skills = [];

    $scope.RemoveSkill = function (id) {
        $http({
            method: 'POST',
            url: '/Home/RemoveSkill',
            data: { skillId: id }
        }).then(
            function (response) {
                GetSkills();
            },
            function (errResponse) {
                console.log('Error Found')
            }
            );
    };

    //Save New Skill
    $scope.AddSkill = function () {
        $scope.id = id++;
        $scope.skillParameter = {
            "name": $scope.name,
            "rate": $scope.rate,
            "id": $scope.id,
        };

        $http({
            method: 'POST',
            url: '/Home/AddSkill',
            data: { newSkill: $scope.skillParameter }
        }).then(
            function (response) {
                if (response.data != '') {
                    GetSkills();
                }
                else {
                    alert("That skill was already added before.");
                }
          
            },
            function (errResponse) {
                console.log('Error Found')
            }
            );

    }

    //Get All Skills
    function GetSkills() {
        $http({
            method: 'GET',
            url: '/Home/GetSkills',
        }).then(
            function (response) {
                $scope.skills = [];
                for (var i = 0; i < response.data.length; i += 1) {
                    $scope.skills.push({ 'name': response.data[i].Name, 'rate': response.data[i].Rate +'', 'id': response.data[i].Id });
                }

                $scope.name = null;
                $scope.rate = null;
                $scope.id = null;
            });
    }

    $scope.loadEvents = function () {
        GetSkills();
    }; 

    $scope.ChangeRate = function (item) {
        $http({
            method: 'POST',
            url: '/Home/ChangeRate',
            data: { skill: item }
        }).then(
            function (response) {
                GetSkills();
            },
            function (errResponse) {
                console.log('Error Found')
            }
            );
    };
}]);