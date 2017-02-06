define( [
	"../ajax"
], function( jQuery ) {

jQuery._evalUrl = function( url ) {
	return jQuery.ajax( {
		url: url,

		// Make this explicit, since user can override this through ajaxSetup (#11264)
		type: "GET",
		dataType: "script",
<<<<<<< HEAD
=======
		cache: true,
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
		async: false,
		global: false,
		"throws": true
	} );
};

return jQuery._evalUrl;

} );
