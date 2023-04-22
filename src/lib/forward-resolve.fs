\ lib/forward-resolve.fs

\ This file is part of Sin Forth.

\ This file adds `>resolve` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
