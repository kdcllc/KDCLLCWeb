// Older "accept" file extension method. Old docs: http://docs.jquery.com/Plugins/Validation/Methods/accept
<<<<<<< HEAD
$.validator.addMethod("extension", function(value, element, param) {
	param = typeof param === "string" ? param.replace(/,/g, "|") : "png|jpe?g|gif";
	return this.optional(element) || value.match(new RegExp("\\.(" + param + ")$", "i"));
}, $.validator.format("Please enter a value with a valid extension."));
=======
$.validator.addMethod( "extension", function( value, element, param ) {
	param = typeof param === "string" ? param.replace( /,/g, "|" ) : "png|jpe?g|gif";
	return this.optional( element ) || value.match( new RegExp( "\\.(" + param + ")$", "i" ) );
}, $.validator.format( "Please enter a value with a valid extension." ) );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
