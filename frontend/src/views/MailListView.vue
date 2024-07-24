<template>
  <div>
      <h1>Mail List</h1>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Email</th>
            <th scope="col">Create Date</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in apiData" :key="item.id">
            <th scope="row">{{ item.id }}</th>
            <td>{{ item.email }}</td>
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
      axios.get('http://localhost/api/Maillist/GetMailList')
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
<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
