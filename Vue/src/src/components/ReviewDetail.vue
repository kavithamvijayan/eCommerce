<template>
    <div>
        <b-list-group>
            <b-list-group-item class="flex-column align-items-start"  v-for="review in reviews" v-bind:key="review.id" >
                
                <div class="d-flex w-100 justify-content-between">
                    <p><b>{{review.title}}</b></p>                    
                </div>

                <p class="mb-1">
                   <b>{{review.name}}</b>: {{review.body}}
                </p>
            </b-list-group-item>
            <b-list-group-item>
                <div class="mt-50">
             <b-button variant="outline-primary" :to="`/giftdetail/${giftId}/addReview`">Add Review</b-button>
        </div>
            </b-list-group-item>
            <br/><br/>
        </b-list-group>
        
    </div>    
</template>
<script>
//import Review from "./Review";
export default {
    name: "ReviewDetail"/*,
    components:{
        Review
    }*/,
    data(){
        return{
            giftId : this.$route.params.id
        }
        
    },
    props: ['reviews']
}
</script>
<style>
.mt-50{
    margin-top: 50px;
}
</style>