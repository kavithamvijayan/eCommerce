<template>
	<tr>
		<td data-th="Product">
			<div class="row">
				<div class="col-sm-2 d-none d-sm-block">
					<img :src="cartItem.image ? require(`../assets/`+cartItem.image):''"  alt="..." class="img-fluid"/>
				</div>
				<div class="col-sm-10">
					<h4 class="nomargin">{{ cartItem.name }}</h4>
					<p>{{ cartItem.desc }}</p>
				</div>
			</div>
		</td>
		<td data-th="Price">{{ cartItem.Price }}</td>
		<td data-th="Quantity">
		<!--	<input type="number" class="form-control text-center"
				:value="cartItem.quantity"
				@input="updateQuantity"
				min="0">-->
				<!--<b-col>
                        <b-button @click="addToCart" variant="success">+</b-button>
                    </b-col>-->
                    <b-col>
                       
                {{cart.filter(x=>x.giftId == cartItem.id)[0].quantity}}
                    </b-col>
                    <!--<b-col>
                        <b-button @click="removeFromCart" variant="danger">-</b-button>
                    </b-col>-->
		</td>
		<td data-th="Subtotal" class="text-center">${{cart.filter(x=>x.giftId == cartItem.id)[0].quantity * cartItem.Price}}</td>
		<td class="actions" data-th="">
			<button class="btn btn-danger btn-sm" @click="removeItemFromCart(cartItem)"><font-awesome-icon icon="trash"/></button>
		</td>
	</tr>
</template>

<script>
	import { mapActions } from 'vuex';
	export default {
		props: ['cartItem'],
		computed: {
			subtotal() {
				return this.cartItem.quantity * this.cartItem.Price;
			}
		},data(){
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
		methods: {
			...mapActions(['updateCart', 'removeItemInCart']),
			removeItem() {
				let vm = this;
				this.removeItemInCart({
					item: vm.cartItem
				});
			},
			updateQuantity(event) {
				let vm = this;
				this.updateCart({
					item: vm.cartItem,
					quantity: parseInt(event.target.value),
					isAdd: false
				});
            },
            removeItemFromCart: function(gift){
            this.$store.commit("removeItemFromCart", gift.id);
        }
		}
	}
</script>
