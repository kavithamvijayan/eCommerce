<?php
    include "pagestart.php";
    include "handlers.php";

    define('TABLE', 'purchasegifts');
    define('COLUMNS', 'ID, quantity, orderId, itemId');

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

        $cmd = 'INSERT INTO ' . TABLE . ' (quantity, orderId, itemId) ' .
            'VALUES (:quantity, :orderId, :itemId)';
        $sql = $GLOBALS['db']->prepare($cmd);
        $sql->bindValue(':quantity', $order['quantity']);

        $sql->bindValue(':orderId',$order['orderId']);
        $sql->bindValue(':itemId',$order['itemId']);
        $sql->execute();
    }

    function update($order, $id){
            $cmd = 'UPDATE '.TABLE.' SET quantity = :quantity WHERE ID= :id';
            $sql = $GLOBALS['db']->prepare($cmd);
            $sql->bindValue(':quantity', $order['quantity']);
            $sql->bindValue(':id', $id);
            return $sql->execute();
    }


?>