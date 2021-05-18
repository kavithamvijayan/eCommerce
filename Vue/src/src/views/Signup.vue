<template>
  <div class="row">
    <div class="col-md-6 offset-md-3 col-sm-10 offset-sm-1">
     <form id="register-form" role="form">
       <br/>  <br/>  <br/>  <br/>
        <h3 class="text-center">Register</h3>
        <br/>  
        <div class="form-group">
          <input type="email" name="email" id="email" class="form-control" placeholder="Email Address" value=""
          v-model="email">
        </div>
        <div class="form-group">
          <input type="password" name="password" id="password" class="form-control" placeholder="Password"
          v-model="password">
        </div>
        <div class="form-group">
          <input type="address" name="address" id="address" class="form-control" placeholder="Address"
          v-model="address">
        </div>
        <div class="form-group">
          <input type="postalcode" name="postalcode" id="postalcode" class="form-control" placeholder="Postal Code"
          v-model="postalcode">
        </div>
        <div class="form-group">
            <b-button style="margin-top: 10px" to="/" variant="success">Create an account</b-button>
        </div>
        <div class="form-group">
          <div class="row">
            <div class="col-lg-12">
              <div class="text-center">
                <router-link to="/Login"><a>Login</a></router-link>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>
<script>
  export default {
    name:"Signup",
    data() {
      return {
      }
    }
  }
</script>