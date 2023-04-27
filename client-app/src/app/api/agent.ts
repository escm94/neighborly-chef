import axios, { AxiosResponse } from 'axios';
import { Meal } from '../models/meal';

axios.defaults.baseURL = 'http://localhost:5000/api';

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const Meals = {
  list: () => requests.get<Meal[]>('/meals'),
  details: (id: string) => requests.get<Meal>(`/meals/${id}`),
  create: (meal: Meal) => requests.post<void>('/meals', meal),
  update: (meal: Meal) => requests.put<void>(`/meals/${meal.id}`, meal),
  delete: (id: string) => requests.del<void>(`/meals/${id}`),
};

const agent = {
  Meals,
};

export default agent;
