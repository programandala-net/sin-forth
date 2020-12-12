\ lib/zero-branch.fs

\ This file is part of Sin Forth.

\ This file adds `0branch` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012120147.
\ See change log at the end of the file.

\ ==============================================================

require pop-hl.fs

get-order get-current

\ target-definitions
compiler-definitions

: 0branch \ Compilation: ( -- )
          \ Run-time:    ( f -- )
  target{ pop-hl }    \ pop hl
  compiler{ l a ld, } \ ld a,l \ XXX REMARK `compiler{` is needed
                               \ because `l` is a word of Gforth.
  h or,               \ or h   ; HL = zero?
  $0000 z? ?jp,       \ jp z,0 ; jump if zero, to an address which…
                      \        ; …will be resolved by `>resolve`
  ;

  \ doc{
  \
  \ 0branch ( f -- ) "zero-branch"
  \
  \ A run-time procedure to branch conditionally. If  _f_
  \ is false (zero), a Z80 ``jp`` is executed to an address
  \ resolved during the compilation.
  \
  \ // XXX TODO
  \ // See also: `branch`, `?branch`, `-branch`, `+branch`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-12: Finish and document.
