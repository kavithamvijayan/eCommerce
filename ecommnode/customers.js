let ObjectId = require("mongodb").ObjectID;
module.exports = (app, db) => {
    //methord to get all informations from database 
    app.get("/customers", async (req, res) => {
        let customers = await db.find("Customer");
     
        res.send(customers);
    });

    //methord to get information from databse by id
    app.get("/customers/:id", async (req, res) => {
        let Id = req.params.id;
      
        let customer = await db.find("Customer", {
            _id: {
                $eq: new ObjectId(Id)
            }
        });
   
        res.send(customer);
    });


    //method to insert information to database 
    app.post("/customers", async (req, res) => {

     
        let newCustomer = {
            "name": req.body.name,
            "email": req.body.email,
            "address": req.body.address,
            "gender": req.body.gender
        }

        let customer = await db.insertOne("Customer", newCustomer);
      
        res.send(customer);
    });
    
    //methord to delete information to database
	app.delete("/customers/:id", async (req, res) => {
        let Id = req.params.id;
        let customer = await db.deleteOne("Customer", {
            _id: new ObjectId(Id)
        });
        res.send(customer);
    });

    //methord to update information to database
    app.put("/customers/:id", async (req, res) => {

        let newCustomer = {
            "name": req.body.name,
            "email": req.body.email,
            "address": req.body.address,
            "gender": req.body.gender
        }
        let Id = new ObjectId(req.params.id);
        let customer = await db.updateOne("Customer", {
            _id: Id
        }, newCustomer);
        res.send(customer);
    });

    
}