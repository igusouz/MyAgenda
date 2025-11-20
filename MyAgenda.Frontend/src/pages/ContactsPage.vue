<script setup>
import { ref, onMounted } from "vue";
import api from "../api/http";

const contacts = ref([]);

async function fetchContacts() {
  try {
    const response = await api.get("/contacts"); // rota da API
    contacts.value = response.data;
  } catch (error) {
    console.error("Erro ao carregar contatos:", error);
  }
}

onMounted(() => {
  fetchContacts();
});
</script>

<template>
  <div>
    <h1>Lista de Contatos</h1>
    <ul>
      <li v-for="contact in contacts" :key="contact.id">
        {{ contact.name }} - {{ contact.email }} - {{ contact.phone }}
      </li>
    </ul>
  </div>
</template>