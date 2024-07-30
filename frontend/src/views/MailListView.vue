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
          <tr v-for="item in apiData.items" :key="item.id">
            <th scope="row">{{ item.id }}</th>
            <td>{{ item.email }}</td>
            <td>{{ this.$formatDate(item.createDate,'MM/DD/YYYY') }}</td>
          </tr>
        </tbody>
      </table>
      <DemoPagination :pageIndex="queryConfig.pageIndex" :pageSize="queryConfig.pageSize" :totalPages="apiData.totalPages" @change-page-config="changePageConfig"/>
    </div>
</template>
<script>
import axios from 'axios';
import DemoPagination from '../components/Pagination.vue'

export default {
  components: {
    DemoPagination
  },
  data() {
    return { 
      queryConfig: { "orderBy": "id", "isDesc": false, "pageIndex": 1,"pageSize": 2 },
      apiData: [],
    };
  },
  mounted(){
    this.fetchData();
  },
  methods: {
    fetchData() {
      axios.post('http://localhost/api/Maillist/GetMailList',this.queryConfig)
        .then(response => {
          console.log(response.data);
          const data = response.data;
          this.apiData = data.data;
        })
        .catch(error => {
          console.error(error);
        });
    },
    changePageConfig(newPageIndex,newPageSize) {
      this.queryConfig.pageIndex =newPageIndex;
      this.queryConfig.pageSize = newPageSize;
      this.fetchData();
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
