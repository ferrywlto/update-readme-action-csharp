## update-readme-action-csharp

### Purpose
This repository contains a public Custom Docker Container GitHub Action that:
- To let you update your `README.md` about your recent activities on:
  1. [Medium](https://medium.com/)
  2. [Stackoverflow](https://stackoverflow.com/)
- To demostrate:
  1. How to create a Custom Docker Container GitHub Action
  2. It can be done in .NET6 and C#
  3. Instead of using other's action like [gautamkrishnar/blog-post-workflow](https://github.com/gautamkrishnar/blog-post-workflow), make your own.

Note that there is nothing wrong to use other's actions to speed up your work and objective. (In fact `gautamkrishnar/blog-post-workflow` is a great one). However, although we always strive to not "re-invent the wheels", as a developer you should understand how it works as well. If you want to promote yourself with a stunning profile, what will better than writing some code by yourself? An account contains only other's code is not a good idea for building up a professional developer image IMHO.

The code also written in a way that is easy to extend for adding more blog post source, and easy to configure.

### Usage

This action contains 3 parameters:

| Name | Default | Order
| :-- | :-- | :-- |
| file-to-update | README.md | 1 |
| medium-user-id | unknown | 2 |
| stackoverflow-user-id | unknown | 3 |

Sample code

<b>Note: You should use GitHub repository/environment secrets for your user IDs</b>

```yaml
- name: Load blog posts and update README.md
  id: update-readme
  uses: ferrywlto/update-readme-action-csharp@v1
  with:
    medium-user-id: ${{ secrets.MEDIUM_USER_ID }}
    stackoverflow-user-id: ${{ secrets.STACKOVERFLOW_USER_ID }}
```
