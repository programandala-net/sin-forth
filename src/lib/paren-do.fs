\ lib/paren-do.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1823+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require d-p.fs        \ `dp`
require plus-store.fs \ `+!`

get-order get-current

target-definitions

: (do) ( -- do-sys )

set-current set-order
