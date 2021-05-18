let ObjectId = require("mongodb").ObjectID;
module.exports = (app, db) => {
    // Fuction for getting the records from database 
    app.get("/gifts", async (req, res) => {
        let gifts = await db.find("gifts");
        res.send(gifts);
    });

// Fuctions for inserting the records to the database
    app.post("/gifts", async (req, res) => {

        let newGift = {
            "name": req.body.name,
            "price": req.body.price,
            "image": req.body.image,
            "desc": req.body.desc,
            "shipping_cost": req.body.shipping_cost
        }

        let gift = await db.insertOne("gifts", newGift);
        res.send(gift);
    });
// Fuctions for updating the records in the database with id
    app.put("/gifts/:id", async (req, res) => {

        let newGift = {
            "name": req.body.name,
            "price": req.body.price,
            "image": req.body.image,
            "desc": req.body.desc,
            "shipping_cost": req.body.shipping_cost
        }
        let Id = parseInt(req.params.id);
        let gift = await db.updateOne("gifts", {
            _id: Id
        }, newGift);

        res.send(gift);
    });
// Fuctions for deleting the records from the database with id
    app.delete("/gifts/:id", async (req, res) => {
        let Id = req.params.id;
        let gift = await db.deleteOne("gifts", {
            _id: new ObjectId(Id)
        });
        res.send(gift);
    });
// Fuction for getting the records from database with id
    app.get("/gifts/:id", async (req, res) => {
        let Id = req.params.id;
        let gift = await db.find("gifts", {
            _id: {
                $eq: new ObjectId(Id)
            }
        });
        res.send(gift);
    });
}