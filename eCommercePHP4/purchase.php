<?php
    include "pagestart.php";
    include "handlers.php";

    define('TABLE', 'purchase');
    define('COLUMNS', 'ID,userId, grandTotal');

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



    function insert($order)
    {
        $cmd = 'INSERT INTO ' . TABLE . ' (grandTotal, userId) ' .
            'VALUES (:grandTotal, :userId)';
        $sql = $GLOBALS['db']->prepare($cmd);
        $sql->bindValue(':userId', $order['userId']);
        $sql->bindValue(':grandTotal', $order['grandTotal']);
        return $sql->execute();
        
    }
    

    function update($order, $id){
            $cmd = 'UPDATE '.TABLE.' SET grandTotal = :grandTotal WHERE ID= :id';
            $sql = $GLOBALS['db']->prepare($cmd);
            $sql->bindValue(':grandTotal', $order['grandTotal']);
            $sql->bindValue(':id', $id);
            return $sql->execute();
    }

?>