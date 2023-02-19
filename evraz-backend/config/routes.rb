require 'sidekiq/web'

Rails.application.routes.draw do
  mount RailsAdmin::Engine => '/admin', as: 'rails_admin'
  # Define your application routes per the DSL in https://guides.rubyonrails.org/routing.html
  Sidekiq::Web.use Rack::Auth::Basic do |username, password|
    username == 'evraz' && password == 'wCpbUEm5fuWJWE'
  end
  mount Sidekiq::Web => '/sidekiq'
  # Defines the root path route ("/")
  # root "articles#index"
  namespace :api do
    resources :aspirators, only: %i[index show]
    resources :sinter_machines, only: %i[index show]
    resources :chart_values, only: [:index]
    resources :signal_kinds, only: [:index]
    resources :issue_requests, only: [:index]
    get '/time_machine/available_spots', to: 'time_machine#available_spots'
  end
end
