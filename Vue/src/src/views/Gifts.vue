<template>

    <b-container>
      <div id="app">
    <Slider />
  </div>
        <b-row>
            <b-col md="6" v-for="gift in gifts" v-bind:key="gift.id" >
                <GiftItem :gift="gift"/>
            </b-col>
        </b-row>
    </b-container>

</template>
<!--<template>
  <div class="container-fluid mt-4">
    <h1 class="h1">Food Records</h1>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-row>
      <b-col>
        <table class="table table-striped">
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th>Value</th>
              <th>Date Time</th>
              <th>&nbsp;</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="record in gifts" :key="record.id">
              <td>{{ record.id }}</td>
              <td>{{ record.name }}</td>
              <td>{{ record.image }}</td>
              <td>{{ record.desc }}</td>
              <td class="text-right">
                <a href="#" @click.prevent="updateFoodRecord(record)">Edit</a> -
                <a href="#" @click.prevent="deleteFoodRecord(record.id)">Delete</a>
              </td>
            </tr>
          </tbody>
        </table>
      </b-col>
      <b-col lg="3">
        <b-card :title="(model.id ? 'Edit Food ID#' + model.id : 'New Food Record')">
          <form @submit.prevent="createFoodRecord">
            <b-form-group label="Name">
              <b-form-input type="text" v-model="model.name"></b-form-input>
            </b-form-group>
            <b-form-group label="Value">
              <b-form-input rows="4" v-model="model.value" type="number"></b-form-input>
            </b-form-group>
            <b-form-group label="Date Time">
              <b-form-input rows="4" v-model="model.dateTime" type="datetime-local"></b-form-input>
            </b-form-group>
            <div>
              <b-btn type="submit" variant="success">Save Record</b-btn>
            </div>
          </form>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>-->
<script>
import GiftItem from "../components/GiftItem";
//import api from '@/EcommerceApiService';
import Slider from "@/components/Slider";
export default {
    name: "gifts",
     components:{
        GiftItem,
        Slider
    },
    data(){
        return{
            gifts: this.$store.state.gifts
        }
    }

    /*data() {
      return {
        loading: false,
        records: [],
        model: {}
      };
    },
    async created() {
      this.getAll()
    },
    methods: {
      async getAll() {
        this.loading = true

        try {
          this.gifts = await api.getAll()
        } finally {
          this.loading = false
        }
      },
      async updateFoodRecord(foodRecord) {
        // We use Object.assign() to create a new (separate) instance
        this.model = Object.assign({}, foodRecord)
      },
      async createFoodRecord() {
        const isUpdate = !!this.model.id;

        if (isUpdate) {
          await api.update(this.model.id, this.model)
        } else {
          await api.create(this.model)
        }

        // Clear the data inside of the form
        this.model = {}

        // Fetch all records again to have latest data
        await this.getAll()
      },
      async deleteFoodRecord(id) {
        if (confirm('Are you sure you want to delete this record?')) {
          // if we are editing a food record we deleted, remove it from the form
          if (this.model.id === id) {
            this.model = {}
          }

          await api.delete(id)
          await this.getAll()
        }
      }
    }
    */
}
</script>