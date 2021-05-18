const http = require('http');
// const path = require('path');

// const shortid = require('shortid');
// const fileUpload = require('express-fileupload')();

const expInst = require('express');
const express = new expInst();
const server = http.createServer(express);
const bodyParser = require('body-parser');
const cookieSession = require('cookie-session');

const db = require('./db.js');
db.init();

//use npm to add the bcrypt library
const bcrypt = require('bcryptjs');

//generate a salt value to combine with the password for hashing

let salt = bcrypt.genSaltSync();

//generate a hash value between the user's password and the salt

let hash = bcrypt.hashSync('password', salt);

//... later, compare a received password with the hash we store

let isValid = bcrypt.compareSync('password', hash);

// express.use(expInst.static(path.resolve(__dirname, 'client')));
express.use(bodyParser.urlencoded({
    extended: true
}));
express.use(bodyParser.json());
express.use(
    cookieSession({
        name: 'session',
        keys: ['key1', 'key2'],
    })
);
// express.use(fileUpload);

require("./gifts")(express, db);
require("./customers")(express, db);
require("./purchase")(express, db);
require("./reviews")(express, db);

server.listen(8081, '0.0.0.0', () => {
    let addr = server.address();
    console.log(`listening on ${addr.port}`);
});