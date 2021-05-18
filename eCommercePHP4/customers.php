<?php
include "pagestart.php";
include "handlers.php";

define('TABLE', 'customers');
define('COLUMNS', 'email, password');


$verb = strtolower($_SERVER['REQUEST_METHOD']);

if ($verb == 'get') {
    handleGet(TABLE, COLUMNS);
} else if ($verb == 'post') {
    handlePost('isValidInsert', 'insert');
} else if ($verb == 'put') {
    handlePut('isValidUpdate', 'update');
} else if ($verb == 'delete') {
    handleDelete(TABLE);
}

# validation code for user object on insert
function isValidInsert($user)
{   
    echo $user;
    return isset($user['email']) &&
           isset($user['password']) ;
}

# validation code for user object on update
function isValidUpdate($user, $id)
{
    return isValidInsert($user) && is_numeric($id) && $id > 0;
}

# DB insert for customer
function insert($user)
{   
    $cmd = 'INSERT INTO ' . TABLE . ' (email, firstName, lastName, password) ' .
        'VALUES (:email, :firstName, :lastName, :password)';
    $sql = $GLOBALS['db']->prepare($cmd);
    var_dump($user['email']);
    $sql->bindValue(':email', $user['email']);
    $sql->bindValue(':firstName', $user['firstName']);
    $sql->bindValue(':lastName', $user['lastName']);
    $sql->bindValue(':password', password_hash($user['password'], PASSWORD_BCRYPT));
    $sql->execute();
}

# DB update for customer
function update($user, $id)
{
    # update the record
    $cmd = 'UPDATE ' . TABLE .
        ' SET email = :email, password = :password ' .
        'WHERE ID = :id';
    $sql = $GLOBALS['db']->prepare($cmd);
    $sql->bindValue(':email', $user['Email']);
    $sql->bindValue(':password', password_hash($user['password'], PASSWORD_BCRYPT));
    $sql->bindValue(':id', $id);
    # execute returns true if the update worked, so we don't actually have to test
    # to see if the record exists before attempting an update.
    return $sql->execute();
}


?>