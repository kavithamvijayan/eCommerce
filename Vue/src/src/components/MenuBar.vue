<template>
<nav class="navbar navbar-expand-sm navbar-dark bg-dark" role="navigation">
  <div class="container">
    <router-link to="/" class="navbar-brand mr-auto">Santa's Gifts</router-link>
    <b-navbar>
      <b-navbar-nav class="headerText">
        <b-nav-item to="/gifts">Gifts</b-nav-item>
      </b-navbar-nav>
      <b-navbar-nav class="ml-auto">
        <b-nav-item to="/mycart">
          <font-awesome-icon icon="shopping-cart" />
          <span>{{numInCart}}</span>
        </b-nav-item>
        <b-nav-item to="/ChangePassword">
          Change password
        </b-nav-item>
        <b-nav-item v-if="$store.state.customer.email.length == 0" to="/login">Login</b-nav-item>
        <b-navbar-nav v-else>
          <b-nav-item>{{$store.state.customer.email}}</b-nav-item>
          <b-nav-item @click="logout">Logout</b-nav-item>
        </b-navbar-nav>
      </b-navbar-nav>
    </b-navbar>
  </div>
  </nav>
</template>
<script>
export default {
  name: "MenuBar",
  computed: {
    numInCart: function() {
      return this.$store.state.cart.length;
    }
  },
  methods: {
    logout: function() {
      this.$store.commit("logoutMutation");
    }
  }
};
</script>
<style scoped>
/*.header {
  background: rgb(168, 14, 14);
}
.nav-item {
  background: rgb(255, 255, 255);
  border-radius: 15%;
  margin-left: 5%;
  margin-right: 5%;
}*/
</style>