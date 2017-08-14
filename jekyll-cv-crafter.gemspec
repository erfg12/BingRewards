# coding: utf-8

Gem::Specification.new do |spec|
  spec.name          = "jekyll-cv-crafter"
  spec.version       = "0.1.0"
  spec.authors       = ["streetturtle"]
  spec.email         = ["streetturtle@gmail.com"]

  spec.summary       = %q{ Jekyll powered CV generator. Features:
 - Lightweight - just 3 files: yml with information about you, html/liquid template and css.
 - Font Awesome icons + Bootstrap.
 - Could be easily integrated in already existing site/blog hosted on Github using Jekyll data files.
 - Data is separated from the view - just fill the YAML file to create your CV.
 - You can easily modify the template or create a new theme according to your needs.
}
  spec.homepage      = "http://pavelmakhov.com/jekyll-cv-crafter/"
  spec.license       = "MIT"

  spec.files         = `git ls-files -z`.split("\x0").select { |f| f.match(%r{^(assets|_data|LICENSE|README)}i) }

  spec.add_runtime_dependency "jekyll", "~> 3.4"

  spec.add_development_dependency "bundler", "~> 1.12"
  spec.add_development_dependency "rake", "~> 10.0"
end
