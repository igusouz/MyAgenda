<script setup>
import { ref, onMounted } from "vue";
import CreateContactForm from "../components/contacts/CreateContactForm.vue";
import EditContactForm from "../components/contacts/EditContactForm.vue";
import ContactList from "../components/contacts/ContactList.vue";
import { api } from "../api/http"

const contacts = ref([]);
const showCreateModal = ref(false);
const showEditModal = ref(false);
const selectedContact = ref(null);

const loadContacts = async () => {
  const res = await api.get("/contacts");
  contacts.value = res.data;
};

const openCreate = () => showCreateModal.value = true;
const openEdit = (contact) => {
  selectedContact.value = contact;
  showEditModal.value = true;
};

onMounted(loadContacts);
</script>

<template>
  <h1>MyAgenda</h1>
  <button @click="openCreate">Novo Contato</button>

  <ContactList 
    :contacts="contacts" 
    @edit="openEdit" 
    @deleted="loadContacts"
  />

  <CreateContactForm 
    v-if="showCreateModal" 
    @close="showCreateModal = false" 
    @created="loadContacts"
  />

  <EditContactForm 
    v-if="showEditModal" 
    :contact="selectedContact" 
    @close="showEditModal = false" 
    @updated="loadContacts"
  />
</template>