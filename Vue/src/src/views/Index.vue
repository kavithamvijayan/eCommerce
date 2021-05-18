

<template>

  <section class="wrapper">
    <header class="image-holder">
      <div class="header-title">Santa's Gifts</div>
      <h4 class="header-subTitle">Shop & Browse the Christmas gifts for your friends and family</h4>
      <b-button variant="primary" class="navLink" to="/gifts">Start Shopping</b-button>
    </header>
    
  </section>
</template>

<script>
// @ is an alias to /src
// import HelloWorld from "@/components/HelloWorld.vue";
//import MenuBar from "../components/MenuBar";

export default {
  name: "Index"/*,
  components: {
    Slider
  }*/
};
</script>
<style scoped>
*,
*::after,
*::before {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
html {
  font-size: 62.5%;
}
body {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
.wrapper {
  max-width: 100vw;
  min-height: 100vh;
  font-family: "Raleway";
}
.header {
  width: 100%;
  height: 30vh;
  background: rgb(139, 6, 6);
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  margin-bottom: 3rem;
}
.spantext {
  text-decoration: none;
}
.header-title {
  font-family: "Raleway";
  font-size: 8rem;
  font-weight: bold;
  text-align: center;
  color: #fff;
  padding-top: 10%;
}
.header-subTitle {
  text-align: center;
  font-weight: 300;
  color: #eee;
}
.navLink {
  height: 2rem;
  display: inline-block;
  padding: 0 1.5rem;
  background: #fff;
  color: black;
  font-family: "Raleway";
  font-weight: bold;
  text-align: center;
  border: none;
  outline: none;
  margin-top: 2rem;
}
.image-holder {
  background-image: url("https://images.pexels.com/photos/1303086/pexels-photo-1303086.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260");
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center center;
  height: calc(100vh - 60px);
}
@media screen and (max-width: 500px) {
  .header-title {
    font-size: 1.8rem;
  }
  .header-subTitle {
    font-size: 0.8rem;
  }
}
</style>

