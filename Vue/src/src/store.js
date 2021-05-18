import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    gifts:[
      {
        id:1,
        Price: 25,
        name: "Christmas Tree",
        image :"photo-of-christmas-tree.jpg",
        desc : "Conveniently sized for living room, dining room, or any other indoor area. Material: Plastic, Color: Green Package Contents: 1 Christmas Tree Christmas Tree for decoration.",
        reviews:[
          {
            id: 1,
            name:"Kavitha Vijayan",
            title: "Very good quality",
            body: "Very good quality and packing is to great.. well satisfied with the Xmas tree.. on time delivery by customer expectations."
          },
          {
            id: 2,
            name:"Chanchal",
            title: "Tree for home decoration",
            body: "I bought this tree for my home decoration purpose to keep at one corner of home, It's made of good quality doesn't look like odd, This is helpful to decorate the house area..."
          },
          {
            id: 3,
            name:"Negin",
            title: "awesome product this price range",
            body: "Made a very good Christmas return gift for children.Loved the product. Good quality & fun filled way of making it."
          },
          {
            id: 4,
            name:"Negin",
            title:"Poor scrawny tree",
            body: "Scrawny tree. You almost feel sorry for it. Not like the one in the advertisement picture. See for yourself on my picture. All decoration is not included."
          },
        ]
      },
      {
        id:2,
        Price: 30,
        name: "Girl and penguine Figurine" ,
        image :"girl-and-penguin-figurine.jpg",
        desc : "Good Quality Product Toy for Kids, Attractive, very cute dolls, loveable, Kids Friendly, Baby Dolls Made of Good Quality Non Toxic Rubber. Great festival gift: a great gift for kids' birthday, children's day, Christmas, New Year, and holiday celebrating.",
        reviews:[
          {
            id: 1,
            name:"Anonymous",
            title: "Cute doll",
            body: "Very cute n lovely doll.my little daughter is in love wth it."
          },
          {
            id: 2,
            name:"Chanchal",
            title: "Disappointed",
            body: "Too small for the cost."
          },
          {
            id: 3,
            name:"Kavitha",
            title: "Great",
            body: "Nice product"
          },
        ]
      },
      {
        id:3,
        Price: 50,
        name: "Copper String Lights Rice Light",
        image :"lights.jpg",
        desc : "Flexible & Durable: Micro super bright LED lights on ultra-thin copper wire with 3 or 5 inches distance between LED bulbs, you can use it to cover virtually any area or structure and increase the visual appeal in your setting",
        reviews:[
          {
            id: 1,
            name: "Kavitha",
            title: "Everything you could want on fairy lights",
            body: "This is a very solid fairy light and one string is enough to cover your curtains or for hanging pictures. This is however not a replacement for over night Christmas lights . it runs on batteries and if left overnight could last only upto 8 hours. However these are beautiful for room decoration or for parties."
          },
          {
            id: 2,
            name: "Sonal",
            title: "Good quality but unhappy",
            body: "I pick this up after seeing these lights at a friend's place. The lights are not bright at all even in the dark. Happy with the packaging and quality of product. Not happy with the lights and photos put up by other reviews showing that they are bright."
          },
          {
            id: 3,
            name: "Negin",
            title: "Led light poor..",
            body: "Led not that bright... as compared to Tony spark led.."
          },
          {
            id: 4,
            name: "Amrit",
            title: "Beautiful",
            body: "So pretty! They look like fireflies in my garden. Only thing is the wire is silver not copper."
          },
        ]
      },
      {
        id:4,
        Price: 20,
        name: "Small Christmas Stocking Classic Socks",
        image :"Stockings.jpg",
        desc : "High quality non-woven fabric + mesh cloth material, soft, comfortable, non polluting and safe.",
        reviews:[
          {
            id: 1,
            name: "Anonymous",
            title: "Love it!",
            body: "First time I got the package one stocking was padded and one wasn't. Seller was helpful and called to rectify the mistake. Resent the order which was much better. Just wish it was a little bigger."
          },
          {
            id: 2,
            name: "Kavitha",
            title: "Good quality stalking",
            body: "Amazing quality"
          },
          {
            id: 3,
            name: "Kavitha",
            title: "Disappointing",
            body: "The 9 inch tall claim made me expect a pretty big stocking but it really isn't, plus the mouth is too narrow for slightly bigger gifts to go through."
          },
        ]
      },
      {
        id:5,
        Price:12,
        name: "Christmas Wreath" ,
        image :"rings.jpg",
        desc : "Leoie Christmas Wreath Garland Hanging Pendant Stylish for Home Door Showcase Decor",
        reviews:[
          {
            id: 1,
            name: "Chanchal",
            title: "Excellent for decoration",
            body: "Excellent item for decoration. The quality is good and size is good enough. It fell down 3times from where I hung it and its still fine and unbroken"
          },
          {
            id: 2,
            name: "Jaspreet",
            title: "One of the pieces was broken, disappointed",
            body: "One of the pieces was broken, disappointed"
          },
          {
            id: 3,
            name: "Kavitha",
            title: "Worth to buy",
            body: "Excellent product. Received as shown in the pic."
          },
          {
            id: 4,
            name: "Kavitha",
            title: "Good product",
            body: "Good product"
          },
        ]
      },
      {
        id:6,
        Price:12,
        name: "Christmas Cap" ,
        image :"caps.jpg",
        desc : "Suitable for adult women and men to wear. Soft velvet/christmas santa claus hat/cap, very delicate and elegant",
        reviews:[
          {
            id: 1,
            name: "Negin",
            title: "Good",
            body: "Good quality, but the white band in the picture seems broader than the actual product"
          },
          {
            id: 2,
            name: "Aishu",
            title: "It's good but is not very warm",
            body: "It's good but is not very warm. Gives a great look and my wife and I clicked some awesome selfies!"
          },
        ]
      },
    ],
    customer:{
      email:"",
      password:""
    },
    cart:[]
  },
  mutations: {
    customerEmail(state, email){
      state.customer.email = email;
    },
    logoutMutation(state){
      state.customer.email = "";
    },
    addToCart(state, myGift){
     // console.log(myGift);
      let giftInBasket = state.cart.filter(i=>i.giftId == myGift.gift.id);
      if(giftInBasket.length){
        state.cart = [...state.cart.filter(gift=>gift.giftId != myGift.gift.id), {giftId: myGift.gift.id, quantity: myGift.quantity}];
      }else{
        state.cart = [...state.cart, {giftId: myGift.gift.id, quantity: myGift.quantity}]
      }
    },
    removeFromCart(state, myGift){
      //console.log(myGift);
      let giftInBasket = state.cart.filter(i=>i.giftId == myGift.gift.id);
      //console.log(giftInBasket);
      if(giftInBasket.length > 1){
        state.cart = [...state.cart.filter(gift=>gift.giftId != myGift.gift.id), {giftId: myGift.gift.id, quantity: myGift.quantity}];
      }else if(myGift.quantity== 0){
        //console.log("im here");
        state.cart = [...state.cart.filter(gift=>gift.giftId != myGift.gift.id)];
      }
    },
    removeItemFromCart(state, id){
      state.cart= [...state.cart.filter(x=>x.giftId != id)]
    },
    addReview(state, review){
      let {giftId,name, title, body} = review;
      let currItem = state.gifts.filter(i => i.id == giftId)[0];
      let newId = currItem.reviews.length +1;
      currItem.reviews.push({id: newId,name, title, body});
      state.gifts = [...state.gifts.filter(o => o.id != giftId), currItem];
    }
  },
  actions: {}
});
