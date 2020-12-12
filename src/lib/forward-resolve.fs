\ lib/forward-resolve.fs

\ This file is part of Sin Forth.

\ This file adds `>resolve` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072206.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
