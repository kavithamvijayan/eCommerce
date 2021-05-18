import Vue from "vue";
import Router from "vue-router";
import Index from "./views/Index.vue";
import Gifts from "./views/Gifts";
import MyCart from "./views/MyCart";
import Login from "./views/Login";
import Signup from "./views/Signup";
import ChangePassword from "./views/ChangePassword";
import GiftDetail from "./views/GiftDetail";
import AddReview from "./views/AddReview";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "index",
      component: Index
    },
    {
      path: "/gifts",
      name: "gifts",
      component: Gifts
    },
    {
      path: "/login",
      name: "login",
      component: Login
    },
    {
      path: "/changepassword",
      name: "changepassword",
      component: ChangePassword
    },
    {
      path: "/signup",
      name: "signup",
      component: Signup
    },
    {
      path:"/giftdetail/:id",
      name:"giftdetail",
      component: GiftDetail
    },{
      path: "/mycart",
      name:"mycart",
      component: MyCart
    },
    {
      path:"/giftdetail/:id/addreview",
      name: "addreview",
      component: AddReview
    }
  ]
});
