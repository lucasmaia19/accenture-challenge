import {createRouter, createWebHistory} from "vue-router";
import Ping from "../components/Ping.vue";
import Company from "../components/Company/Company.vue";
import Supplier from "../components/Supplier/Supplier.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: "/",
            name: "Company",
            component: Company,
        },
        {
            path: "/supplier",
            name: "Supplier",
            component: Supplier,
        },
        {
            path: "/ping",
            name: "ping",
            component: Ping,
        },
        /* {
          path: '/about',
          name: 'about',
          // route level code-splitting
          // this generates a separate chunk (About.[hash].js) for this route
          // which is lazy-loaded when the route is visited.
          component: () => import('../views/AboutView.vue')
        }*/
    ],
});

export default router;
