<template>
    <div>
        <b-card bg-variant="light">
            <b-form-group
            label-cols-lg="3"
            label="Add Review"
            label-size="lg"
            label-class="font-weight-bold pt-0"
            class="mb-0"
            >
                <b-form-group
                    label-cols-sm="3"
                    label="Title:"
                    label-align-sm="right"
                    label-for="nested-title"
                >
                    <b-form-input v-model="title" id="nested-title"></b-form-input>
                </b-form-group>

                <b-form-group
                    label-cols-sm="3"
                    label="Body:"
                    label-align-sm="right"
                    label-for="nested-body"
                >
                    <b-form-textarea v-model="body" id="nested-body"></b-form-textarea>
                    
                </b-form-group>  

                    <input type="file" @change="onFileChanged">
<button @click="onUpload">Upload!</button>
                               
                <b-form-group>
                    <b-button @click="addReview" variant="outline-primary">Submit</b-button>
                </b-form-group>
            </b-form-group>
            
        </b-card>
    </div>
</template>
<script>
export default {
    name: "AddReview",
    data(){
        return{
            name:"",
            title:"",
            body:"",
            selectedFile:""
        }
    },
    methods:{onFileChanged (event) {
    this.selectedFile = event.target.files[0]
  },
  onUpload() {
     const formData = new FormData()
  formData.append('myFile', this.selectedFile, this.selectedFile.name)
<<<<<<< HEAD:Vue/src/views/AddReview.vue
  //axios.post('my-domain.com/file-upload', formData)
=======
  axios.post('my-domain.com/file-upload', formData)
>>>>>>> e921ad566e4d71d75239b758c202386ba8a7079a:Vue/src/src/views/AddReview.vue
  },
        addReview: function(){
            
            if(this.$store.state.customer.email.length == 0){
                this.name ="Anonymous"
            } else {
                this.name =this.$store.state.customer.email
            }
            if(this.title && this.body){
                let reviewdetail = {
                    giftId : this.$route.params.id,
                    title: this.title,
                    body: this.body,
<<<<<<< HEAD:Vue/src/views/AddReview.vue
                    image: this.image,
                    name:this.name
=======
                    image: this.image
>>>>>>> e921ad566e4d71d75239b758c202386ba8a7079a:Vue/src/src/views/AddReview.vue
                }
                this.$store.commit("addReview", reviewdetail);
                this.$router.push({ path: `/giftdetail/${this.$route.params.id}`});
            }else {
              alert("Fields shouldn't be empty");
            }
        }
    }
}
</script>