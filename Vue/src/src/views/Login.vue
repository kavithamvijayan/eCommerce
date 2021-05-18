<!--<template>
    <b-container >
        <div >
            <b-form-input style="margin-top: 100px" v-model="email" placeholder="Email"></b-form-input>
            <b-form-input type="password" style="margin-top: 10px" v-model="password" placeholder="Password"></b-form-input>
            <b-button style="margin-top: 10px" @click="login" variant="success">Login</b-button>
             <b-button style="margin-top: 10px"  to="/signup" variant="success">Create an account/update</b-button>
        </div>
    </b-container>
</template>-->
<template>
<div class="row">
  <div class="col-md-6 offset-md-3 col-sm-12 offset-sm-1">
    <form id="login-form" role="form" style="display: block;">
        <br/>  <br/>  <br/>  <br/>
      <h3 class="text-center">Login</h3>  <br/>
      <div class="form-group">
        <input type="email" name="email" id="email" class="form-control" placeholder="Email Address" v-model="email">
      </div>
      <div class="form-group">
        <input type="password" name="password" id="password" class="form-control" placeholder="Password" v-model="password">
      </div>
  <br/>
      <div class="form-group">
        <button class="btn btn-success" style="width: 100%" @click="login">
            <i v-if="isLoading" class="fa fa-spinner fa-spin" />
						Log in
					</button>
      </div>
      <div class="form-group">
        <div class="row">
          <div class="col-lg-12">
            <div class="text-center">
              <router-link to="/Signup"><a>Register</a></router-link>
            </div>
          </div>
        </div>
        
      </div>
      <div class="form-group">
        <div class="row">
          <div class="col-lg-12">
            <div class="text-center">
              <router-link to="/ChangePassword"><a>Change Password</a></router-link>
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
    name:"login",
    data(){
        return{
            email: "",
            password: ""
        }
    },
    methods:{
        login: function(){
            if(this.email && this.password){
                this.$store.commit("customerEmail", this.email);
                this.$router.push("/");
            } else {
              alert("Email and/or password shouldn't be empty");
            }
        }
    }
}
</script>