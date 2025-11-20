import { createRouter, createWebHistory } from "vue-router";
import ContactsPage from "../pages/ContactsPage.vue";

const routes = [
  {
    path: "/",
    redirect: "/contacts",
  },
  {
    path: "/contacts",
    name: "contacts",
    component: ContactsPage,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;