<template>
  <div>
    <div class="mt-4">
      <el-input
          v-model="queryParams.search"
          placeholder="Type to search"
          style="max-width: 600px"
          @input="searchData"
      >
        <template #prepend>
          <el-button :icon="Search" @click="searchData"/>
        </template>
        <template #append>
          <el-button type="primary">Search</el-button>

        </template>
      </el-input>
    </div>
    <el-table :data="apiData.data.items"
              :default-sort="{ prop: 'id', order: 'descending' }"
              stripe
              style="width: 100%"
              @sort-change="changeOrder"
    >
      <el-table-column label="ID" prop="id" sortable width="180"/>
      <el-table-column label="Email" prop="email" sortable/>
      <el-table-column label="Description" prop="description" sortable/>
      <el-table-column label="Create Date" prop="createDate" sortable/>
      <el-table-column width="360">
        <template #header>
          Operations
        </template>
        <template #default="scope">
          <el-popconfirm
              cancel-button-text="No, Thanks"
              confirm-button-text="Yes"
              icon-color="#626AEF"
              title="Are you sure to remove this email?"
              width="220"
              @confirm="handleDelete(scope.row.email)"
          >
            <template #reference>
              <el-button
                  type="danger"
              >
                Remove
              </el-button>
            </template>
          </el-popconfirm>
        </template>
      </el-table-column>
    </el-table>
    <DemoPagination :count="apiData.data.totalCount" :index="queryParams.pageIndex" :mySize="queryParams.pageSize"
                    @page-change="pageChange"/>
  </div>
</template>
<script lang="ts" setup>
import {Search} from "@element-plus/icons-vue";
import api, {APIResponse, QueryConfig, QueryResult, Subscription} from "@/common/api"
import DemoPagination from "@/components/Pagination.vue";
import {onMounted, reactive, toRefs, watch,} from 'vue'
import {useRouter} from 'vue-router'
import {ElMessage} from "element-plus";

const router = useRouter()

const props = defineProps({
  mySize: {
    default: 10,
    type: Number
  }
})
let {mySize} = toRefs(props)


const queryParams = reactive<QueryConfig>({
  orderBy: "id",
  isDesc: true,
  pageIndex: 1,
  search: "",
  pageSize: mySize,
})
let lastSearch = null;
let apiData = reactive<APIResponse<QueryResult<Subscription>>>({
  code: 0,
  data: {
    items: [],
    totalPages: 0,
    totalCount: 0,
    pageIndex: 0,
    pageSize: 0,
  },
  message: ''
})

function fetchData() {
  api.subscriptions.list(queryParams).then(data => {
    console.log("subscriptions:", data)
    apiData.data = data.data
    apiData.code = data.code
    apiData.message = data.message

  })
}

function pageChange(index: number, size: number) {
  queryParams.pageIndex = index
  queryParams.pageSize = size
}

function changeOrder(orderOp) {
  console.log(orderOp);
  queryParams.orderBy = orderOp.prop;
  if (orderOp.order == "descending") {
    queryParams.isDesc = true;
  } else if (orderOp.order == "ascending") {
    queryParams.isDesc = false;
  } else {
    queryParams.isDesc = false;
    queryParams.orderBy = "id";

  }
}

function handleDelete(email: string) {
  api.subscriptions.delete(email).then(response => {
    console.log(response.data)
    if (response.code == 0) {
      ElMessage({
        message: 'Congrats, this mail has been removed!',
        type: 'success',
      })
      fetchData()
    } else {
      ElMessage.error(response.message)
    }
  })
}


watch(
    () => {
      queryParams.pageSize, queryParams.pageIndex , queryParams.isDesc, queryParams.orderBy
    },
    () => {
      fetchData()
    },
    {deep: true}
)

function searchData() {
  clearTimeout(lastSearch);
  lastSearch = setTimeout(() => {
    fetchData();
  }, 700);

}

onMounted(() => {
  fetchData()
})
</script>