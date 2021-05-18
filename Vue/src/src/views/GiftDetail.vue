<!--<template>
    <b-container>
        <b-row class="mb-100">
            <b-col>
                <b-row>
                    <h1 class="mt-50">{{gift.name}}</h1>    
                </b-row>
                <b-row>
                    <div class="item-img imgSize">
                        <b-img :src="gift.image ? require(`../assets/`+gift.image):''" />
                    </div>
                </b-row>
                <b-row class="mt-50">
                    <h3>Description</h3>
                    <hr>
                    <h6 class="align-left">{{gift.desc}}</h6>
                </b-row>
            </b-col>
            <b-col>
                <b-row class="mt-200">
                    <b-col>
                        <b-button @click="addToCart" variant="success">+</b-button>
                    </b-col>
                    <b-col>
                        {{quantity}}
                    </b-col>
                    <b-col>
                        <b-button @click="removeFromCart" variant="danger">-</b-button>
                    </b-col>
                </b-row>
                <b-row>
                    <ReviewDetail class="mt-50 w-100" v-bind:reviews="gift.reviews" />
                </b-row>
            </b-col>

        </b-row>
    </b-container>
</template>-->
<template>
<div class="container">
  <div class="col-md-12">
    <div v-if="isProductLoading" class="text-center">
      <grid-loader :loading="isProductLoading" :color="loaderColor" :size="loaderSize" class="d-inline-block" />
    </div>
    <div v-else class="card">
      <div class="row">
        <div class="col-12 col-md-4 offset-md-4">
          <div class="intrinsic">
            <img class="img-fluid intrinsic-item" :src="gift.image ? require(`../assets/`+gift.image):''" alt="">
          </div>
        </div>
      </div>

      <div class="caption-full">
        <h4 class="pull-right">$ {{ gift.Price }}</h4>
        <h4> {{ gift.name }}</h4>
        <p> {{ gift.desc }} </p>
      </div>
      <div> <b-row class="mt-200">
                    <b-col>
                        <b-button @click="addToCart" variant="success">+</b-button>
                    </b-col>
                    <b-col>
                        {{quantity}}
                    </b-col>
                    <b-col>
                        <b-button @click="removeFromCart" variant="danger">-</b-button>
                    </b-col>
                </b-row></div>
      <div class="ratings">
        <p class="pull-right">
          <button @click="addToCart" :disabled="gift.quantity === 0" class="btn btn-success">
                            Add to cart
                        </button>
        </p>
        <div class="clearfix"></div>
      </div>
      <div> 
          <h2>Reviews</h2>
          <ReviewDetail class="mt-50 w-100" v-bind:reviews="gift.reviews" /></div>
    </div>
  </div>
</div>
</template>
<script>
import ReviewDetail from "../components/ReviewDetail";
export default {
    name: "GiftDetail",
    components:{
        ReviewDetail
    },
    data(){
        return{
            quantity: this.$store.state.cart.filter(i=>i.giftId == this.$route.params.id).length > 0 ? this.$store.state.cart.filter(i=>i.giftId == this.$route.params.id)[0].quantity : 0 ,
            gift: this.$store.state.gifts.filter(i=>i.id == this.$route.params.id)[0]
        }
    },
    methods:{
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
        }
    }
}
</script>
<style scoped>
    .mt-50{
        margin-top: 50px;
    }
    .mt-200{
        margin-top: 100px;
    }    
    .align-left{
        text-align: left;
    }
    .w-100{
        width: 100%;
    }
    .mb-100{
        margin-bottom: 100px;
    }
    .imgSize {
        height:100px;
        width:100px;
    }
    .caption-full {
  padding-right: 10px;
  padding-left: 10px;
  
}
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
body {
  margin: 0px;
}

.ratings {
  padding-right: 10px;
  padding-left: 10px;
  color: #d17581;
}
</style>