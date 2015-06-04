var options = {
	  enableHighAccuracy: true,
	  timeout: 5000,
	  maximumAge: 0
	};	
setInterval(function(){ navigator.geolocation.getCurrentPosition(success, error, options); }, 15000);		

//success for getting location information.
function success(pos) {
  var crd = pos.coords;
  var elm = $("#label");
  //var url = "http://88.208.211.53:3000/location/" + '10' + "/" + crd.latitude + "," + crd.longitude;
  //alert(url);
  sendLocInfo('10', crd.latitude + "," + crd.longitude);
  elm.html('Your current position is: <p>' + 'Latitude : ' + crd.latitude + 'Longitude: ' + crd.longitude + '</p>');
  //console.log('Your current position is:');
  //console.log('Latitude : ' + crd.latitude);
  //console.log('Longitude: ' + crd.longitude);
  //console.log('More or less ' + crd.accuracy + ' meters.');
};

//error for getting location information.
function error(err) {
var elm = $("#label");
  elm.html('ERROR(' + err.code + '): ' + err.message);
  //console.warn('ERROR(' + err.code + '): ' + err.message);
};



function sendLocInfo(id, latlong){
				// Using the core $.ajax() method
				$.ajax({
				 
				    // The URL for the request
				    url: "http://88.208.211.53:3000/location/" + id + "/" + latlong,				 
				 
				    // Whether this is a POST or GET request
				    type: "GET",
				 
				    // The type of data we expect back
				    dataType : "json",
				 
				    // Code to run if the request succeeds;
				    // the response is passed to the function
				    success: function( json ) {
				        
				    },
				 
				    // Code to run if the request fails; the raw request and
				    // status codes are passed to the function
				    error: function( xhr, status, errorThrown ) {
				        //alert( "Sorry, there was a problem!" );
				        //console.log( "Error: " + errorThrown );
				        //console.log( "Status: " + status );
				        //console.dir( xhr );
				    },
				 
				    // Code to run regardless of success or failure
				    complete: function( xhr, status ) {
				       //alert( "The request is complete!" );
				    }
				});
			}
