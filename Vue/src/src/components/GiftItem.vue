<template>
    <b-card
    :title="gift.name"
    :img-src="require('../assets/'+gift.image)"
    img-alt="Image"
    img-top
    tag="article"
    style="max-height: 100rem;"
    class="mb-2"
  >
    <b-card-text>
      {{gift.desc ? gift.desc : ""}}
    </b-card-text>
    <b-card-text>
      Price: $ {{gift.Price ? gift.Price : ""}}
    </b-card-text>
    <b-button :to="`/giftdetail/${gift.id}`" variant="primary">Click here for more details</b-button>
  </b-card>
</template>
<script>

export default {
    name: "GiftItem",
    props:["gift"]
   
}
</script>
