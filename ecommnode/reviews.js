let ObjectId = require("mongodb").ObjectID;
module.exports = (app, db) => {
    // Fuction for getting the records from database 
    app.get("/reviews", async (req, res) => {
        let reviews = await db.find("reviews");
     
        res.send(reviews);
    });
    // Fuction for getting the records from database with id 
    app.get("/reviews/:id", async (req, res) => {
        let Id = req.params.id;
        let reviews = await db.find("reviews", {
            _id: {
                $eq: new ObjectId(Id)
            }
        });
        res.send(reviews);
    });

// Fuctions for inserting the records to the database
    app.post("/reviews", async (req, res) => {

        let newReview = {
            "giftId": req.body.giftId,
            "title": req.body.title,
            "body": req.body.body
        }

        let gift = await db.insertOne("reviews", newReview);
        res.send(reviews);
    });
// Fuctions for updating the records in the database with id
    app.put("/reviews/:id", async (req, res) => {

        let newReview = {
            "giftId": req.body.giftId,
            "title": req.body.title,
            "body": req.body.body
        }
        let Id = new ObjectId(req.params.id);
        let gift = await db.updateOne("reviews", {
            _id: Id
        }, newReview);
        res.send(reviews);
    });
// Fuctions for deleting the records from the database with id
    app.delete("/reviews/:id", async (req, res) => {
        let Id = req.params.id;
        let gift = await db.deleteOne("reviews", {
            _id: new ObjectId(Id)
        });
        res.send(reviews);
    });
}