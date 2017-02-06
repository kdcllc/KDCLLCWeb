<<<<<<< HEAD
$.validator.addMethod("time", function(value, element) {
	return this.optional(element) || /^([01]\d|2[0-3]|[0-9])(:[0-5]\d){1,2}$/.test(value);
}, "Please enter a valid time, between 00:00 and 23:59");
=======
$.validator.addMethod( "time", function( value, element ) {
	return this.optional( element ) || /^([01]\d|2[0-3]|[0-9])(:[0-5]\d){1,2}$/.test( value );
}, "Please enter a valid time, between 00:00 and 23:59" );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
