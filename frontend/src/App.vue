<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <div>
    <div class="skippy visually-hidden-focusable overflow-hidden">
      <div class="container-xl">
        <a class="d-inline-flex p-2 m-1" href="#content">Skip to main content</a>

      </div>
    </div>
    <header class="navbar-expand-lg bd-navbar sticky-top"> 
      <nav class="navbar navbar-expand-lg bg-body-tertiary">
      <div class="container-fluid">
        <a class="navbar-brand mb-0 h1" href="/">
          <img src="@/assets/logo.svg" alt="Logo" width="30" height="24" class="d-inline-block align-text-top">
          &ensp;Demo
        </a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
              <RouterLink to="/">Product</RouterLink>
            </li>
            <li class="nav-item">
              <RouterLink to="/mailList">Mail List</RouterLink>
            </li>
            
            <!-- <li class="nav-item">
              <a class="nav-link disabled" aria-disabled="true">Disabled</a>
            </li> -->
          </ul>
          <!-- <form class="d-flex" role="search">
            <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
            <button class="btn btn-outline-success" type="submit">Search</button>
          </form> -->
        </div>
      </div>
    </nav>
    </header>
    <main>
      <div class="bd-masthead mb-3" id="content">
        <div class="container-xxl bd-gutter">
          <div class="bd-content">
            <RouterView />
          </div>
        </div>
      </div>
    </main>
    <footer>
      <div class="container py-4 py-md-5 px-4 px-md-3 text-body-secondary">
        <div class="row">
          
          <div class="col-lg-3 mb-3">
            <a class="d-inline-flex align-items-center mb-2 text-body-emphasis text-decoration-none" href="/" aria-label="Shop">
              <img src="@/assets/logo.svg" alt="Logo" width="30" height="24" class="d-inline-block align-text-top"><title>Shop</title>
              <span class="fs-5">&ensp;Demo</span>
            </a>
            <ul class="list-unstyled small">
              <li class="mb-2">jockhuang@gmail.com</li>
              <li class="mb-2">&copy;2024 Jock</li>
            </ul>
          </div>
        </div>
      </div>
    </footer>
  </div>
</template>

<style scoped>
.logo {
  display: block;
  margin: 0 auto 2rem;
}

nav a.router-link-exact-active {
  color: var(--color-text);
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}


</style>
