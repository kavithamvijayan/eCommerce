let ObjectId = require("mongodb").ObjectID;
module.exports = (app, db) => {
   //methord to get informatons from database
    app.get("/purchase", async (req, res) => {
        let purchases = await db.find("purchase");
        
        res.send(purchases);
    });

    //methord to get information from databse by id
    app.get("/purchase/:id", async (req, res) => {
        let Id = req.params.id;
        //console.log(Id);
        // Id = parseInt(Id);
        let purchase = await db.find("purchase", {
            _id: {
                $eq: new ObjectId(Id)
            }
        });
        //console.log(purchase);
        res.send(purchase);
    });


    //method to insert information to database 
    app.post("/purchase", async (req, res) => {

        //console.log(req.body);
        let newPurchase = {
            "cusId": req.body.cusId,
            "giftId": req.body.giftId
        }

        let purchase = await db.insertOne("purchase", newPurchase);
        // console.log(gift);
        res.send(purchase);
    });

    //methord to update information to database
    app.put("/purchase/:id", async (req, res) => {

        //console.log(req.body);
        let newPurchase = {
            "cusId": req.body.cusId,
            "giftId": req.body.giftId
        }
        let Id = new ObjectId(req.params.id);
        let purchase = await db.updateOne("purchase", {
            _id: Id
        }, newPurchase);
        //console.log(purchase);
        res.send(purchase);
    });

    //methord to delete information from database
    app.delete("/purchase/:id", async (req, res) => {
        let Id = req.params.id;
        //console.log(Id);
        // Id = parseInt(Id);
        let purchase = await db.deleteOne("purchase", {
            _id: new ObjectId(Id)
        });
        // console.log(purchase);
        res.send(purchase);
    });
}