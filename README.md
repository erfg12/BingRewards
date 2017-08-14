# Jekyll CV Crafter

[![Gem Version](https://badge.fury.io/rb/jekyll-cv-crafter.svg)](https://badge.fury.io/rb/jekyll-cv-crafter)

Jekyll powered CV generator. 
Check the [demo](http://pavelmakhov.com/jekyll-cv-crafter/).

## Features

 - Lightweight - just 3 files: yml with information about you, html/liquid template and css.
 - Font Awesome icons + Bootstrap.
 - Could be easily integrated in already existing site/blog hosted on Github using Jekyll [data](http://jekyllrb.com/docs/datafiles/) files.
 - Data is separated from the view - just fill the YAML file to create your CV.
 - You can easily modify the template or create a new theme according to your needs.
 
## Installation

Clone/download this repo.

 - `_data/cv.yml` contains info about you;
 - `index.html` markup of the CV;
 - `css/cv.scss` styles.

So only thing you need to do is to fill the `cv.yml`. 
As I mentioned above you can easily integrate this CV in your blog (if it's hosted on github pages) by putting `cv.yml` in `_data` folder of your blog, `cv.scss` in `css` folder of your blog and renaming `index.html` to `cv.html`.
 
PRs/issues/comments are welcome! Don't hesitate to contact me in case of any questions.
