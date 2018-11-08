from django.conf.urls import url
from . import views

urlpatterns = [
    #what app to go to
    url(r'^$', views.index),
]
