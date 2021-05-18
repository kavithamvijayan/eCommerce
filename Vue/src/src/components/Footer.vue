 
 <template><footer class="navbar-default navbar-bottom navbar-dark bg-dark">
      <div class="container-fluid">
            <p class="text-center nav-bar mb-0">Copyright: Santa's Gifts</p>
      </div>
    </footer>
    </template>
    
<style>
  #reset-store-panel {
    position: fixed; bottom: 0px; right: 0px;
  }

  body, .sticky-footer-wrapper {
     min-height:100vh;
  }

  .flex-fill {
     flex:1 1 auto;
  }
  footer {
      position: fixed;
      width:100%;
      bottom:0;
    height: 40px;
    color: #666;
    padding: 10px 0 10px 0;
    font-size: 85%;
    
  }
  footer a {
    color: #999;
  }
  footer a:hover {
    color: #efefef;
  }
  @media (max-width: 576px) {
    footer {
      height: 50px;
    }
  }
</style>