//http://www.bennadel.com/blog/2610-using-jsonp-with-resource-in-angularjs.htm
angular.module('lrdnug', ['ngResource'])
    .controller('IndexCtrl', function ($scope, DataService) {
        $scope.HelloText = "Hello World";
        $scope.Meetings = [];
        DataService.getMeetings().$promise.then(function (meetings) {
            //$scope.Meetings.length = 0;
            //angular.forEach(meetings, function (meeting) {
            //    $scope.Meetings.push(meeting);
            $scope.Meetings = meetings;
            console.log(meetings.get());
        }, function (error) {
            console.log('error'+ error);
        });
    })
    .factory('DataService', function ($resource) {
        return $resource(
            'http://localhost:1302/api/meetings/',
            { callback: 'JSON_CALLBACK' },
            {
                getMeetings: {
                    method: 'JSONP',
                    isArray:true
                }
            });
    });
