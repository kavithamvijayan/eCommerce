<template>
    <b-container>
        <br/><h1>My Cart</h1><br/>
        <table id="cart" class="table table-hover table-sm">
    <thead>
      <tr>
        <th style="width:50%">Product</th>
        <th style="width:10%">Price</th>
        <th style="width:8%">Quantity</th>
        <th style="width:22%" class="text-center">Subtotal</th>
        <th style="width:10%"></th>
      </tr>
    </thead>
    
    <transition-group name="list-shopping-cart" tag="tbody">
      <app-cart-item v-for="cartItem in giftsInCart" :cartItem="cartItem" :key="cartItem.id"></app-cart-item>
    </transition-group>
    <tfoot>
      <tr class="d-table-row d-sm-none">
        <td class="text-center"><strong>Total ${{ cartValue }}</strong></td>
      </tr>
      <tr>
        <td>
          <button class="btn btn-warning" >
							<i class="fa fa-angle-left"></i> <router-link to="/gifts"><a>Save and Continue Shopping</a></router-link>
						</button>
        </td>
        <td colspan="2" class="d-none d-sm-table-cell"></td>
        <td class="d-none d-sm-table-cell text-center"><strong>Total ${{ grandTotal }}</strong></td>
        <td class="px-0">
          <button class="btn btn-success" @click="checkout">
							<span class="text-nowrap">Checkout <i class="fa fa-angle-right d-inline"></i></span>
					</button>
        </td>

      </tr>
    </tfoot>
  </table>
     <!--   <b-list-group>
            <b-list-group-item v-for="gift in giftsInCart" :gift="gift" v-bind:key="gift.id" :to="`/giftdetail/${gift.id}`">
                <b-row>
                    <b-col>
                        <h1>{{gift.name}}</h1>
                    </b-col>
                    <b-col>
                        <b-row>
                            <b-col>
                                quantity:<h4>{{cart.filter(x=>x.giftId == gift.id)[0].quantity}}</h4>
                            </b-col>
                            <b-col>
                                Total: <h4>{{cart.filter(x=>x.giftId == gift.id)[0].quantity * gift.Price}}</h4>
                            </b-col>
                            <b-col>
                                <b-button variant="danger" @click="removeItemFromCart(gift)">
                                    <font-awesome-icon icon="trash"/>
                                </b-button>
                            </b-col>
                        </b-row>
                        
                    </b-col>
                </b-row>
            </b-list-group-item>
        </b-list-group>
        <b-row>
            <b-col>
            </b-col>
            <b-col>
                <h4>Grand Total : </h4><h2>{{grandTotal}}</h2>
            </b-col>
        </b-row>-->
    </b-container>
</template>
<script>
import CartItem from "../components/CartItem";
export default {
    name: "MyCart",
  components: {
    appCartItem: CartItem
  },
    data(){
        // let giftsInCart = [];
        // let items = this.$store.state.items;
        // // debugger;
        // this.$store.state.cart.map(function(x){
        //     giftsInCart = [...giftsInCart, items.filter(i=>i.id == x.giftId)[0]];
        // });
        // console.log(giftsInCart);
        return{
            // items: giftsInCart,
            cart: this.$store.state.cart
        }
    },
    computed:{
        giftsInCart: function(){
            let giftsInCart = [];
            let gifts = this.$store.state.gifts;
            // debugger;
            this.$store.state.cart.map(function(x){
                giftsInCart = [...giftsInCart, gifts.filter(i=>i.id == x.giftId)[0]];
            }); 
            return giftsInCart;
        },
        grandTotal: function(){
            let giftsInCart = [];
            let gifts = this.$store.state.gifts;
            // debugger;
            this.$store.state.cart.map(function(x){
                giftsInCart = [...giftsInCart, gifts.filter(i=>i.id == x.giftId)[0]];
            });

            let grandTotal = 0;
            let cart = this.$store.state.cart;
            giftsInCart.map(function(cItem){
                grandTotal += cItem.Price *  cart.filter(i=>i.giftId == cItem.id)[0].quantity;
            });
            return grandTotal;
        }
    },
    methods: {
      addToCart: function(){
            this.quantity++;
            let myGift = {gift: this.gift, quantity: this.quantity};
            
            this.$store.commit("addToCart", myGift);
        },
        removeFromCart: function(){
            if(this.quantity > 0){
                this.quantity--;
                let myGift = {gift: this.gift, quantity: this.quantity};
                this.$store.commit("removeFromCart", myGift);
            }else if(this.quantity == 0){
                let myGift = {gift: this.gift, quantity: this.quantity};
                this.$store.commit("removeFromCart", myGift);
            }     
        },
        removeItemFromCart: function(gift){
            this.$store.commit("removeItemFromCart", gift.id);
        },
    checkout() {
      if (this.giftsInCart.length == 0) {
      alert("No items in cart");
      } else {
        alert("Checkout successful !");
        this.giftsInCart = "";
        this.$store.commit("giftsInCart", this.giftsInCart);
        this.giftsInCart.forEach(element => this.$store.commit("removeItemFromCart", element.id));
      }
    }
    }
}

</script>
<style  scoped>
.list-shopping-cart-leave-active {
  transition: all 0.4s;
}

.list-shopping-cart-leave-to {
  opacity: 0;
  transform: translateX(50px);
}

.table-sm {
  font-size: 0.875rem;
  
}
</style>


