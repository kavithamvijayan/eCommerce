<?php
include "pagestart.php";
include "handlers.php";

define('TABLE', 'gifts');
define('COLUMNS', 'Id, name, price');


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

# validation code for gifts object on insert
function isValidInsert($user)
{   
    echo $user;
    return isset($user['email']) &&
           isset($user['password']) ;
}

# validation code for gifts object on update
function isValidUpdate($user, $id)
{
    return isValidInsert($user) && is_numeric($id) && $id > 0;
}

# DB insert for gifts
function insert($user)
{   
    $cmd = 'INSERT INTO ' . TABLE . ' (name, price) ' .
        'VALUES (:name, :price)';
    $sql = $GLOBALS['db']->prepare($cmd);
    $sql->bindValue(':name', $user['name']);
    $sql->bindValue(':price', $user['price']);
    $sql->execute();
}

# DB update for gifts
function update($user, $id)
{
    # update the record
    echo $id;
    $cmd = 'UPDATE ' . TABLE .
        ' SET name = :name, price = :price ' .
        'WHERE ID = :id';
    $sql = $GLOBALS['db']->prepare($cmd);
    $sql->bindValue(':name', $user['name']);
    $sql->bindValue(':price', $user['price']);
    $sql->bindValue(':id', $id);
    # execute returns true if the update worked, so we don't actually have to test
    # to see if the record exists before attempting an update.
    return $sql->execute();
}


?>