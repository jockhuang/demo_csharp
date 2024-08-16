import axios, {AxiosError, AxiosResponse} from 'axios';

axios.defaults.baseURL = 'http://localhost/api';
// axios.interceptors.request.use((config) => {
//     if (token) {
//         config.headers.Authorization = `Bearer ${token}`;
//     }
//     return config;
// });
axios.interceptors.response.use(
    (res) => res,
    (error: AxiosError) => {
        const {data, status, config} = error.response!;
        switch (status) {
            case 400:
                console.error(data);
                break;
            case 401:
                console.error('unauthorised');
                break;
            case 404:
                console.error('/not-found');
                break;
            case 500:
                console.error('/server-error');
                break;
        }
        return Promise.reject(error);
    }
);
const responseBody = <T>(response: AxiosResponse<T>) => response.data;
const request = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    delete: <T>(url: string, body: {}) => axios.delete<T>(url, body).then(responseBody),
    post: <T>(url: string, body: {}) =>
        axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) =>
        axios.put<T>(url, body).then(responseBody),
};

export interface APIResponse<T> {
    code: number;
    message: string;
    data?: T;
}

export interface Product {
    id: number
    name: string
    description: string
    isRelease: boolean
    price: number
    imageURL?: string
    createDate?: string
    updateDate?: string
}

export interface Subscription {
    id: number
    email: string
    description?: string
    createDate?: string
    updateDate?: string
}

export interface QueryConfig {
    search: string
    orderBy: string
    isDesc: boolean
    pageIndex: number
    pageSize: number
}

export interface QueryResult<T> {
    items: T[]
    totalPages: number
    totalCount: number
    pageIndex: number
    pageSize: number
}

const products = {
    list: (data: QueryConfig) => request.post<APIResponse<QueryResult<Product>>>('/Product/QueryProducts', data),
    details: (id: string) => request.get<APIResponse<Product>>(`/Product/${id}`),
    delete: (id: string) => request.delete<APIResponse<null>>(`/Product/${id}`),
    add: (data: Product) => request.post<APIResponse<Subscription>>('/Product/AddProduct', data),
    update: (id: string, data: Product) => request.put<APIResponse<Subscription>>(`/Product/${id}`, data),

};
const subscriptions = {
    list: (data: QueryConfig) => request.post<APIResponse<QueryResult<Subscription>>>('/MailList/GetMailList', data),
    delete: (data: string) => request.delete<APIResponse<Subscription>>(`/MailList/RemoveSubscription`, {
        params: {
            email: data,
        },
    }),
    add: (data: Subscription) => request.post<APIResponse<Subscription>>('/MailList/AddSubscription', data),
};

const api = {
    products,
    subscriptions,
};
export default api;