\ lib/forward-resolve.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1823+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

\ require d-p.fs        \ `dp`

get-order get-current

compiler-definitions

: >resolve ( orig -- )
  memory> @ swap t-! ;

  \ doc{
  \
  \ >resolve  Compilation: ( orig -- ) "forward-resolve"
  \
  \ Resolve a forward branch by placing the address of the current
  \ data-space pointer into the address _orig_ left by `>mark`.
  \
  \ See also: `here`, `<resolve`.
  \
  \ }doc

set-current set-order
