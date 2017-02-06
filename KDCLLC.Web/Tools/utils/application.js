"use strict";
var yargs_1 = require('yargs');
var fs = require('fs');
exports.ENVIRONMENTS = {
    DEVELOPMENT: 'dev',
    PRODUCTION: 'prod'
};
function getEnvironment() {
    if (yargs_1.argv.env != null) {
        if (yargs_1.argv.env === exports.ENVIRONMENTS.PRODUCTION) {
            return exports.ENVIRONMENTS.PRODUCTION;
        }
        else {
            return exports.ENVIRONMENTS.DEVELOPMENT;
        }
    }
    else {
        return exports.ENVIRONMENTS.DEVELOPMENT;
    }
}
exports.getEnvironment = getEnvironment;
function getApplicationTitle() {
    return JSON.parse(fs.readFileSync("package.json", "utf8")).description;
}
exports.getApplicationTitle = getApplicationTitle;
//# sourceMappingURL=application.js.map