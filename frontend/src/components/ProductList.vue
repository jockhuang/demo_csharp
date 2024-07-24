
<template>
    <div>
      <h1>Product List</h1>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Name</th>
            <th scope="col">Description</th>
            <th scope="col">Create Date</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in apiData" :key="item.id">
            <th scope="row">{{ item.id }}</th>
            <td>{{ item.name }}</td>
            <td>{{ item.description }}</td>
            <td>{{ this.$formatDate(item.createDate,'MM/DD/YYYY') }}</td>
          </tr>
        </tbody>
      </table>
    </div>
</template>
<script>
import axios from 'axios';

export default {
  data() {
    return { 
      apiData: [],
    };
  },
  mounted(){
    this.fetchData();
  },
  methods: {
    fetchData() {
      axios.get('http://localhost/api/Product/GetAllProducts')
        .then(response => {
          console.log(response.data);
          const data = response.data;
          this.apiData = data.data;
        })
        .catch(error => {
          console.error(error);
        });
    }
  }
}
</script>