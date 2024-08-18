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
          <el-button :icon="Search"/>
        </template>
        <template #append>
          <el-button type="primary" @click="searchData">Search</el-button>

        </template>
      </el-input>
    </div>
    <el-table :data="apiData.data.items"
              :default-sort="{ prop: 'id', order: 'descending' }"
              stripe
              style="width: 100%"
              @sort-change="changeOrder"
    >
      <el-table-column label="ID" prop="id" sortable width="80"/>
      <el-table-column label="Name" prop="name" show-overflow-tooltip sortable width="400"/>
      <el-table-column label="Description" prop="description" show-overflow-tooltip sortable/>
      <el-table-column label="Price" prop="price" sortable width="120"/>

      <el-table-column label="Released" prop="isRelease" sortable width="80">

        <template #default="scope">
          <el-switch
              v-model="scope.row.isRelease"
              disabled
              size="small"
          />
          <!-- <el-col :sm="1" :lg="1">
          <el-result :icon="scope.row.isRelease ? 'success' : 'error'" />
          </el-col> -->
        </template>
      </el-table-column>
      <el-table-column label="Create Date" prop="createDate" sortable width="180"/>
      <el-table-column label="Update Date" prop="updateDate" sortable width="180"/>
      <el-table-column width="360">
        <template #header>
          Operations
        </template>
        <template #default="scope">
          <el-button @click="handleEdit(scope.row.id)">
            Edit
          </el-button>
          <el-popconfirm
              cancel-button-text="No, Thanks"
              confirm-button-text="Yes"
              icon-color="#626AEF"
              title="Are you sure to delete this?"
              width="220"
              @confirm="handleDelete(scope.row.id)"
          >
            <template #reference>
              <el-button
                  type="danger"
              >
                Delete
              </el-button>
            </template>
          </el-popconfirm>
        </template>
      </el-table-column>
    </el-table>

    <DemoPagination v-model:count="apiData.data.totalCount" v-model:index="queryParams.pageIndex" v-model:mySize="queryParams.pageSize"
                    @page-change="pageChange"/>
  </div>
</template>
<script lang="ts" setup>
import {Search} from "@element-plus/icons-vue";
import api, {APIResponse, Product, QueryConfig, QueryResult} from "@/common/api"
import DemoPagination from "@/components/Pagination.vue";
import {onMounted, reactive, toRefs, watch} from 'vue'
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
  pageSize: mySize.value,
})
let lastSearch = null;
let apiData = reactive<APIResponse<QueryResult<Product>>>({
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
  console.log("fetchData:", queryParams)
  api.products.list(queryParams).then(data => {
    console.log("response:", data)
    apiData.data = data.data
    apiData.code = data.code
    apiData.message = data.message

  })
}

function pageChange(index: number, size: number) {
  queryParams.pageIndex = index
  queryParams.pageSize = size
}

function handleDelete(id: string) {
  api.products.delete(id).then(response => {
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

function handleEdit(id: string) {
  console.log("handleEdit", id)
  router.push({name: 'EditProduct', params: {slug: id}})
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

